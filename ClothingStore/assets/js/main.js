var listItemThird = document.querySelector('.category-menu-item:nth-child(3)');

var listItems = document.querySelector('.list-items');

var category = document.querySelector('.category');

listItemThird.onclick = function(e) {
    listItems.classList.toggle('hide-box');
    category.classList.toggle('hide-scroll');
    e.preventDefault();
}


listItems.onclick = function(e) {
    e.stopPropagation();
}


var categoryInforItemSecond = document.querySelector('.category-infor-item:nth-child(2)');
var overlay = document.querySelector('.overlay');
var modal = document.querySelector('.modal');

var headElement = document.querySelector('#head');

// Click newsletter
categoryInforItemSecond.onclick = function(e) {
    overlay.classList.remove('hide-box');
    modal.classList.remove('hide-box');
    var style = window.getComputedStyle(headElement);
    if(style.getPropertyValue('height') == '84px') {
        overlay.style.zIndex = '4';
    } 
}


// Click close on modal
var close = document.querySelector('.modal-close');
close.onclick = function(e) { 
    var style = window.getComputedStyle(headElement);
    if(style.getPropertyValue('height') != '84px') {
        overlay.classList.add('hide-box');
    }
    modal.classList.add('hide-box');
    overlay.style.zIndex = '2';
    e.stopPropagation();
}


// Click
var menuIcon = document.querySelector('.menu-icon');
menuIcon.onclick = function(e) {
    overlay.classList.remove('hide-box');
    category.style.display = 'block';

}

var closeMenu = document.querySelector('.category-close-icon');

overlay.onclick = closeMenu.onclick = function(e) { 
    var style = window.getComputedStyle(headElement);
    var overlayStyle = window.getComputedStyle(overlay);
    if(style.getPropertyValue('height') == '84px' && overlayStyle.getPropertyValue('z-index') == '2') {
        overlay.classList.add('hide-box');
        modal.classList.add('hide-box');
        category.style.display = 'none';
    }   
}

