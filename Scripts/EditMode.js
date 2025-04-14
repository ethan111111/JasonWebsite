document.addEventListener("DOMContentLoaded", function () {
    let editMode = false;
    let toggleButton = document.getElementById("toggleEditMode");
    let saveButton = document.getElementById("saveChanges");

    if (toggleButton) {
        toggleButton.addEventListener("click", function () {
            editMode = !editMode;
            let elements = document.querySelectorAll(".editable");

            elements.forEach(function (element) {
                if (editMode) {
                    let textarea = document.createElement("textarea");
                    textarea.value = element.innerText;
                    textarea.className = "editable";
                    element.replaceWith(textarea);
                } else {
                    let newP = document.createElement("p");
                    newP.innerText = element.value;
                    newP.className = "editable";
                    element.replaceWith(newP);
                }
            });

            toggleButton.style.display = editMode ? "none" : "block";
            saveButton.style.display = editMode ? "block" : "none";
        });

        saveButton.addEventListener("click", function () {
            let elements = document.querySelectorAll(".editable");

            let data = [];
            elements.forEach(function (element) {
                data.push(element.value || element.innerText);
            });

            fetch('/Home/SaveText', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ texts: data })
            }).then(response => response.json())
                .then(data => {
                    console.log("Changes Saved:", data);
                    location.reload(); // Refresh to reflect changes
                }).catch(error => console.error("Error saving:", error));
        });
    }
});