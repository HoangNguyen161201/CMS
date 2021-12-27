document.querySelectorAll('.input').forEach(item => {
    item.onclick = () => {
        document.querySelectorAll('.input').forEach(e => {
            e.classList.remove('inputFocus')
        })
        item.classList.add('inputFocus')
    }
})