
const readBtns = document.querySelectorAll('.read-btn');
const readMores = document.querySelectorAll('.read-more');

readBtns.forEach((btn, index) => {
    btn.addEventListener('click', function () {
        readMores[index].style.display = 'inline';
        btn.style.display = 'none';
    });
});

