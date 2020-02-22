# -*- coding:utf8 -*-
import socket
import threading
import struct
import math
import os

bind_ip = "0.0.0.0"  # 绑定ip：这里代表任何ip地址
bind_port = 80

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((bind_ip, bind_port))
# 最大连接数为5
server.listen(5)

print "[*] Listening on %s:%d" % (bind_ip, bind_port)


# uint32 to IP
def ch2(x):
    return '.'.join([str(x/(256**i) % 256) for i in range(0, 4, 1)])
# 这是客户处理进程

def client_socket_close(client_socket):
    print "client_socket is closed"
    client_socket.close()

def file_close(file):
    print "file is close"
    file.close()

def handle_client(client_socket):

    global filePath
    global times
    global files
    global chunk_size
    global flag
    chunk_size = 1024 * 100
    # 打印出客户端发送得到的内容
    while True:

        try:
            request = client_socket.recv(1024)
        except:
            print "Client is disconnection"
            client_socket.close()
            break

        if not request:
            break
        print "[*] Received: %s" % request
        with open('1.txt', 'a+') as f:
            f.write(request)
            f.flush()

        MegVersion = request[0:11]
        sequ = request[18:22]
        sequ = struct.unpack("i",sequ)

        for i in sequ:
            flag = i
            sequ = struct.pack("i",i)

        print "[*] Received sequ: %s" % flag

        # Get message header
        Msghead = "@Send0"  #
        lenme = struct.pack("i", chunk_size)
        tag = struct.pack("i", 0)
        ip = chr(127)+chr(0)+chr(0)+chr(1)
        MegType = request[12:14]

        if request[22:28] == "@NEXT0":
            aa = math.ceil(times)
            bb = math.ceil(flag + 1)
            if math.ceil(times) == math.ceil(flag + 1):
                chunk_data = files.read(chunk_size)
                lenme = struct.pack("i", len(chunk_data))
                send = MegVersion + "1" + MegType + ip + sequ + Msghead + tag + \
                    lenme + "00000000000000000000000000000000000000000000000000" + chunk_data
                client_socket.send(send)
                file_close(files)
                client_socket_close(client_socket)
                break
            chunk_data = files.read(chunk_size)
            send = MegVersion + "0" + MegType + ip + sequ + Msghead + tag + \
                lenme + "00000000000000000000000000000000000000000000000000" + chunk_data
            client_socket.send(send)
        else:
            filePath = request[86:]
            if os.path.exists(filePath):
                times = os.path.getsize(filePath) / (chunk_size * 1.0)
                files = open(filePath, "rb")
                chunk_data = files.read(chunk_size)
                if times <= 1:
                    lenme = struct.pack("i", len(chunk_data))
                    send = MegVersion + "1" + MegType + ip + sequ + Msghead + tag + \
                        lenme + "00000000000000000000000000000000000000000000000000" + chunk_data
                    client_socket.send(send)
                    file_close(files)
                    client_socket_close(client_socket)
                    break

                send = MegVersion + "0" + MegType + ip + sequ + Msghead + tag + \
                    lenme + "00000000000000000000000000000000000000000000000000" + chunk_data
                client_socket.send(send)
            else:
                # file does not exist
                Msghead = "E00001"
                send = MegVersion + "0" + MegType + ip + sequ + Msghead + tag + \
                    lenme + "00000000000000000000000000000000000000000000000000"
                client_socket.send(send)
                client_socket_close(client_socket)
                break


while True:
    client, addr = server.accept()

    print "[*] Accepted connection from: %s:%d" % (addr[0], addr[1])

    # 挂起客户端线程，处理传人的数据
    client_handler = threading.Thread(target=handle_client, args=(client,))
    client_handler.start()
