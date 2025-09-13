# How to use 
## CLI
The cli tool has the name search and can be used as described in the README. 
## API & UI
For both the API and the UI a containerized version is available. To run it execute docker-compose up -d in the root directory of the project.
The UI is then available at http://localhost:3000. The API consists of two endpoints:
- GET /cameras: returns a list of all cameras
- GET /cameras/{name}: returns the camera with the given string in the camera field of the csv.

The test cover the FilterService in its basic functionality. 

## Vibe coding declaration
The code for filling the table was mostly vibe coded. 
Along the way I used ChatGPT and GitHub Copilot to help me get started, with the UI part of the task.

## Additional Ideas
I would have liked to highlight the marker when an element of the list is hovered over or clicked. 
I choose not to do it, as this would have been fully vibe coded, which would defeat the purpose of the exercise.