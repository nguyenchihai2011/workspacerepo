require("dotenv").config();

const express = require("express");
const http = require("http");
const { Server } = require("socket.io");
const cors = require("cors");
const cookieParser = require("cookie-parser");
const mongoose = require("mongoose");
const path = require("path");
const corsOptions = require("./config/cors");
const connectDB = require("./config/database");
const credentials = require("./api/middleware/credentials");
const errorHandlerMiddleware = require("./api/middleware/error_handler");
const authenticationMiddleware = require("./api/middleware/authentication");

const projectRoute = require("./api/routes/projects");
const authRoute = require("./api/routes/auth");
const userRoute = require("./api/routes/users");

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
    const { from, to, message } = data;

    // Kiểm tra người dùng nhận có tồn tại và đã xác thực không
    if (authenticatedUsers.has(to)) {
      const recipientSocketId = authenticatedUsers.get(to);

      // Gửi tin nhắn riêng tới người nhận thông qua socket.id
      io.to(recipientSocketId).emit("privateMessage", { from, message });
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

// Connect Database
connectDB();

// Allow Credentials
app.use(credentials);

// CORS
app.use(cors(corsOptions));

// application.x-www-form-urlencoded
app.use(express.urlencoded({ extended: false }));

// application/json response
app.use(express.json());

// middleware for cookies
app.use(cookieParser());

app.use(authenticationMiddleware);

// static files
app.use("/static", express.static(path.join(__dirname, "public")));

// Default error handler
app.use(errorHandlerMiddleware);

app.get("/", (req, res) => res.send("Hello world!"));
app.use("/auth", authRoute);
app.use("/projects", projectRoute);
app.use("/users", userRoute);

app.all("*", (req, res) => {
  res.status(404);

  if (req.accepts("json")) {
    res.json({ error: "404 Not Found" });
  } else {
    res.type("text").send("404 Not Found");
  }
});

const port = process.env.PORT || 8082;

mongoose.connection.once("open", () => {
  console.log("DB connected");
  server.listen(port, () => {
    console.log(`Listening on port ${port}`);
  });
});
