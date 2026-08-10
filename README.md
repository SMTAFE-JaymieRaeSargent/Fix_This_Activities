# Branch-Based Student Activities

This repository uses **paired Git branches** to separate the student version of an activity from the completed working answer.

The repository is designed primarily for **lecturers and future lecturers maintaining or delivering the class**.

Each activity has two branches:

* **Task branch** — the version students are given to complete.
* **Answer branch** — the completed working version used by the lecturer as a reference or solution.

---

## How the Branches Work

Each activity should have a matching **Task** and **Answer** branch.

For example:

```text
Activity-01-Task
Activity-01-Answer

Activity-02-Task
Activity-02-Answer
```

The exact activity name may change, but each Task branch should have a clearly matching Answer branch.

---

## Task Branch

The **Task branch** contains the version of the project that students are expected to work from.

This branch may include:

* starter code
* commented pseudocode
* incomplete methods
* TODO sections
* partially completed Unity objects or components
* instructions for what the student needs to build
* deliberately unfinished logic that students are expected to complete

The Task branch should **not contain the final working solution**.

When preparing an activity for students, this is the branch that should be used as the starting point.

---

## Answer Branch

The **Answer branch** contains the completed working version of the same activity.

This branch is intended for lecturers and can be used to:

* check the expected solution
* demonstrate the completed activity in class
* troubleshoot student work
* confirm that the activity works before delivery
* compare student code against the intended outcome
* support future lecturers delivering the same class

The Answer branch should contain a tested and working version of the activity.

---

## Recommended Lecturer Workflow

Before delivering an activity:

1. Locate the matching **Task** and **Answer** branches.
2. Open the **Answer** branch first and confirm that the activity still works.
3. Check that the **Task** branch does not accidentally contain the completed solution.
4. Use the **Task** branch as the version students work from.
5. Keep the **Answer** branch available as the lecturer reference.

---

## Example

If the activity is a First Person Controller, the repository might contain:

```text
FirstPersonController-Task
FirstPersonController-Answer
```

The **Task** branch could contain pseudocode such as:

```csharp
// IF LeftShift is pressed THEN
//     SET movement speed to sprint speed
// ELSE
//     SET movement speed to walk speed
// ENDIF
```

Students would then translate that logic into C#.

The **Answer** branch would contain the completed version:

```csharp
if (Input.GetKey(KeyCode.LeftShift))
{
    _movementSpeed = _sprintSpeed;
}
else
{
    _movementSpeed = _walkSpeed;
}
```

This allows the lecturer to keep the learning activity and the completed solution in the same repository while still keeping the two versions separate.

---

## Important: Do Not Merge the Answer into the Task

The Task and Answer branches are intentionally different.

Avoid merging an Answer branch into its matching Task branch unless you are deliberately rebuilding the activity.

Doing so may place the completed solution into the student version.

If changes are required, update both branches separately:

```text
TASK BRANCH
Update the student instructions,
starter files or incomplete code.

        ↓

ANSWER BRANCH
Update the completed solution
to match the revised task.
```

---

## When Updating an Activity

If an activity needs to be changed for a future class, make sure the **Task** and **Answer** branches remain aligned.

For example, if a new requirement is added to the Task branch, the Answer branch should also be updated with the completed version of that requirement.

| Task Branch                             | Answer Branch                   |
| --------------------------------------- | ------------------------------- |
| Contains the student starting point     | Contains the completed solution |
| Contains the activity requirements      | Completes those requirements    |
| May contain pseudocode or TODO comments | Contains working C#             |
| Safe for students to work from          | Lecturer reference              |
| Does not reveal the final answer        | Tested working answer           |

---

## Branch Naming

Where possible, use a consistent naming pattern so Task and Answer branches are easy to match.

Recommended format:

```text
ActivityName-Task
ActivityName-Answer
```

For example:

```text
Variables-Task
Variables-Answer

IfStatements-Task
IfStatements-Answer

PlayerMovement-Task
PlayerMovement-Answer

CameraControl-Task
CameraControl-Answer
```

A consistent naming convention makes it much easier for future lecturers to understand the repository.

---

## Purpose of This Structure

The purpose of the branch structure is to keep **teaching material and solutions together while still keeping them separate**.

Instead of maintaining two separate Unity projects, each activity can exist in the same repository as a paired set of branches:

```text
TASK
Student starting point
        │
        │ Same Activity
        ▼
ANSWER
Completed working version
```

This makes activities easier to maintain, demonstrate, update and reuse across future deliveries.

---

## Quick Reference

**Teaching the activity?**
Use the **Task** branch.

**Need to see the completed solution?**
Use the **Answer** branch.

**Changing the activity?**
Check and update **both** branches.

**Preparing the activity for students?**
Make sure students are working from the **Task** branch and that the completed Answer version is not accidentally included in their starting activity.
