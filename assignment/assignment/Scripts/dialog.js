document.querySelector('.close').onclick = ()=> {
    document.querySelector('.dialog').style.display = "none";
}

document.querySelector('.bt__close').onclick = () => {
    document.querySelector('.dialog').style.display = "none";
}


document.querySelectorAll('.delete').forEach(item => {
    item.addEventListener('click', (e) => {
        const action = e.target.getAttribute('data-action')
        const nameInput = e.target.getAttribute('data-name-input')
        const value = e.target.getAttribute('data-input')
        const name = e.target.getAttribute('data-name')

        document.querySelector('.title-delete').innerHTML = `Delete ${name}`
        document.querySelector('.form-dl').action = action;
        document.querySelector('.delete-input').value = value;
        document.querySelector('.delete-input').name = nameInput;
        document.querySelector('.note').innerHTML = `Do you sure to delete ${name} has is ${value}`;

        document.querySelector('.dialog').style.display = "flex";
    })
})