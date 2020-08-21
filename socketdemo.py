import socket
host = "127.0.0.1"
port = 8300  # port same

message = "Whats popping"

print(f'message from py = {message}')

s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
# AF_NET means ipv4, SOCK_DGRAM means a UDP connection
while True:

    s.sendto(message.encode(), (host, port))
