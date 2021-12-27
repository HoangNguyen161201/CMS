var searchTime
// search
const search = (value, elements)=> {
    clearTimeout(searchTime)
    searchTime = setTimeout(() => {
        if (value) {
            document.querySelectorAll('.item').forEach(e=> {

                e.style.display = "none"
                for (let index = 0; index < elements.length; index++) {
                    const field = e.querySelector(`.${elements[index]}`).innerHTML
                    if (field.toUpperCase().includes(value.toUpperCase())) {
                        e.style.display = "flex"
                    }
                }
            })
        } else {
            document.querySelectorAll('.item').forEach(e=> {
                e.style.display = "flex"
            })
        }
    }, 1000);
}
