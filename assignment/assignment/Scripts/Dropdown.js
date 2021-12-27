document.querySelectorAll('.dropdow').forEach(e=> {
    e.addEventListener('click', ()=> {
        const elements = e.getElementsByClassName('link')
        if(elements.length == 1) {

            e.classList.toggle("drop-open-1")
            e.querySelector('.fa-caret-down').classList.toggle("rotate-180")
        }
        if(elements.length == 2) {

            e.classList.toggle("drop-open-2")
            e.querySelector('.fa-caret-down').classList.toggle("rotate-180")
        }
    })
})