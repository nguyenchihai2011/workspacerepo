const express = require("express");
const router = express.Router();

const User = require("../models/User");

router.get("/", async (req, res) => {
  try {
    const users = await User.find();
    res.json(users);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// router.get("/:id", (req, res) => {
//   Project.findById(req.params.id)
//     .then((project) => res.json(project))
//     .catch((err) =>
//       res.status(404).json({ noprojectfound: "No project found" })
//     );
// });

// router.put("/:id", (req, res) => {
//   Project.findByIdAndUpdate(req.params.id, req.body)
//     .then((project) => res.json({ msg: "Updated successfully" }))
//     .catch((err) =>
//       res.status(400).json({ error: "Unable to update the Database" })
//     );
// });

// router.delete("/:id", (req, res) => {
//   Project.findByIdAndRemove(req.params.id, req.body)
//     .then((project) => res.json({ mgs: "Project entry deleted successfully" }))
//     .catch((err) => res.status(404).json({ error: "No such a project" }));
// });

module.exports = router;
