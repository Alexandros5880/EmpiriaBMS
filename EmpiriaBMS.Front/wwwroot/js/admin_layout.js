

$(document).ready(function () {

    document.getElementById('sidebar-toggle').addEventListener('click', function () {
        var sidebar = document.getElementById('sidebar');
        if (sidebar.style.left === '-250px') {
            sidebar.style.left = '0';
        } else {
            sidebar.style.left = '-250px';
        }
    });


});