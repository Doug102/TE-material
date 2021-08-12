document.addEventListener('DOMContentLoaded', () => {
    const btn = document.querySelector('.btn');
    btn.addEventListener('click', (eventObject) => {
        const dateTime = document.getElementById('time');
        dateTime.innerText = Date();
    });

    const header = document.createElement('h1');
    header.innerText = 'Doug Stauffer';
    const body = document.querySelector('body');
    body.appendChild(header);
});

