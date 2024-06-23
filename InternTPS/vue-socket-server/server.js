const express = require("express");
const http = require("http");
const { Server } = require("socket.io");

const app = express();
const server = http.createServer(app);
const io = new Server(server, {
  cors: {
    origin: "*",
    methods: ["GET", "POST"],
  },
});

const authenticatedUsers = new Map();

io.on("connection", (socket) => {
  socket.on("authenticate", (userId) => {
    // Thực hiện xác thực người dùng và gán socket.id cho người dùng
    authenticatedUsers.set(userId, socket.id);
    console.log(`User ${userId} authenticated with socket ID ${socket.id}`);
  });
  // Xử lý sự kiện privateMessage
  socket.on("privateMessage", (data) => {
    const { to, message } = data;

    // Kiểm tra người dùng nhận có tồn tại và đã xác thực không
    if (authenticatedUsers.has(to)) {
      const recipientSocketId = authenticatedUsers.get(to);

      // Gửi tin nhắn riêng tới người nhận thông qua socket.id
      io.to(recipientSocketId).emit("privateMessage", message);
      console.log(
        `Private message sent from ${socket.id} to ${recipientSocketId}`
      );
    } else {
      console.log(`Recipient ${to} not found or not authenticated`);
    }
  });

  socket.on("disconnect", () => {
    console.log(`user ${socket.id} left.`);
  });
});

server.listen(3000, () => {
  console.log("Chat server is running on 3000");
});
