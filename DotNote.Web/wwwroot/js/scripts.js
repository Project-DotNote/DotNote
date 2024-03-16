$(document).ready(function () {
    all_notes = $("li a");

    all_notes.on("keyup", function () {
        note_title = $(this).find("h2").text();
        note_content = $(this).find("p").text();

        item_key = "list_" + $(this).parent().index();

        data = {
            title: note_title,
            content: note_content
        };

        window.localStorage.setItem(item_key, JSON.stringify(data));
    });

    all_notes.each(function (index) {
        data = JSON.parse(window.localStorage.getItem("list_" + index));

        if (data !== null) {
            note_title = data.title;
            note_content = data.content;

            $(this).find("h2").text(note_title);
            $(this).find("p").text(note_content);
        }
    });
});

const items = [];
const stickyNotes = [];

function addItem() {
    const input = document.getElementById("itemInput");
    const value = input.value.trim();
    if (value !== "") {
        items.push(value);
        input.value = "";
        displayItems();
    }
}

function displayItems() {
    const itemList = document.getElementById("itemList");
    itemList.innerHTML = "";
    items.forEach(item => {
        const li = document.createElement("li");
        li.textContent = item;
        itemList.appendChild(li);
    });
}

function searchItems() {
    const searchInput = document.getElementById("searchInput").value.toLowerCase();
    const filteredItems = items.filter(item => item.toLowerCase().includes(searchInput));
    const searchList = document.getElementById("searchList");
    searchList.innerHTML = "";
    filteredItems.forEach(item => {
        const li = document.createElement("li");
        li.textContent = item;
        searchList.appendChild(li);
    });
}

function addStickyNote() {
    const textarea = document.getElementById("stickyNotes");
    const note = textarea.value.trim();
    if (note !== "") {
        stickyNotes.push(note);
        textarea.value = "";
        displayStickyNotes();
    }
}

function displayStickyNotes() {
    const stickyNoteList = document.getElementById("stickyNoteList");
    stickyNoteList.innerHTML = "";
    stickyNotes.forEach(note => {
        const div = document.createElement("div");
        div.classList.add("sticky-note");
        div.textContent = note;
        stickyNoteList.appendChild(div);
    });
}
