const express = require("express");
const router = express.Router();

const Project = require("../models/Project");

router.get("/", async (req, res) => {
  const { owner } = req.query;
  try {
    let projects;
    if (owner) {
      projects = await Project.find({ owner });
    } else {
      projects = await Project.find();
    }
    res.json(projects);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

router.get("/:id", (req, res) => {
  Project.findById(req.params.id)
    .then((project) => res.json(project))
    .catch((err) =>
      res.status(404).json({ noprojectfound: "No project found" })
    );
});

router.post("/", (req, res) => {
  Project.create(req.body)
    .then((project) => res.json({ msg: "Project added successfully" }))
    .catch((err) =>
      res.status(400).json({ error: "Unable to add this Projects" })
    );
});

router.put("/:id", (req, res) => {
  Project.findByIdAndUpdate(req.params.id, req.body)
    .then((project) => res.json({ msg: "Updated successfully" }))
    .catch((err) =>
      res.status(400).json({ error: "Unable to update the Database" })
    );
});

router.delete("/:id", (req, res) => {
  Project.findByIdAndRemove(req.params.id, req.body)
    .then((project) => res.json({ mgs: "Project entry deleted successfully" }))
    .catch((err) => res.status(404).json({ error: "No such a project" }));
});

module.exports = router;
