# -*- coding:utf8 -*-
import socket
import threading
import struct
import binascii

bind_ip = "0.0.0.0"  # 绑定ip：这里代表任何ip地址
bind_port = 80

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server.bind((bind_ip, bind_port))
# 最大连接数为5
server.listen(5)

print "[*] Listening on %s:%d" % (bind_ip, bind_port)


def file_deal(file_name):
    # 定义函数用于处理用户索要下载的文件
    try:
        # 二进制方式读取
        files = open(file_name, "rb")
        mes = files.read()
    except:
        print "没有该文件"
        return "E00001"
    else:
        files.close()
        return mes


def ch2(x):
    return '.'.join([str(x/(256**i) % 256) for i in range(0, 4, 1)])
# 这是客户处理进程


def handle_client(client_socket):
    # 打印出客户端发送得到的内容
    while True:

        request = client_socket.recv(1024)

        if not request:
            break
        print "[*] Received: %s" % request
        with open('1.txt', 'r+') as f:
            f.write('%s\n' % (request))
            f.flush()

        #print "[*] Received Addr: %s" % request[86:]

        Meghead = request[0:11]
        sequ = request[18:22]
        sequ = struct.unpack('I', sequ)

        #ip = ""
        for i in sequ:
           sequ = struct.pack("i",i)
        print "[*] Received head: %s\n" % Meghead
        print "[*] Received sequ: %s" % sequ

        send = file_deal(request[86:])
        head = "@Send0"
        if send:
            # 如果文件不为空计算发送次数
            if len(send) == 6:
                head = send
                times = [len(send) / (1024 * 1024)]
#            if times < 1:

#                client_socket.send(send)
        lenme = struct.pack("i", 1024)
        
        tag = struct.pack("i", 0)
        ip = chr(47)+chr(93)+chr(239)+chr(77)
        send = Meghead + "1" + request[12:14] + ip + sequ + head + tag + lenme + "00000000000000000000000000000000000000000000000000" + send
        #print send
    # 发送一个数据包
        client_socket.send(send)
    client_socket.close()


while True:
    client, addr = server.accept()

    print "[*] Accepted connection from: %s:%d" % (addr[0], addr[1])

    # 挂起客户端线程，处理传人的数据
    client_handler = threading.Thread(target=handle_client, args=(client,))
    client_handler.start()
