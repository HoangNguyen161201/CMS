document.querySelectorAll('.iconFunc').forEach(e => {
    e.addEventListener("click", () => {
        var link = document.createElement("a")
        link.href = e.getAttribute('data-url')
        link.click()
    })
})