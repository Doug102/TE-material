document.addEventListener('DOMContentLoaded', () => {

    const button = document.querySelector('div.btn');
    button.addEventListener('click', () => {
        const target = document.getElementById('time');
        target.innerText = Date();
    })
})