
function scrollToTop() {
        window.scrollTo({
            top: 450,
            behavior: 'smooth'
        })
    console.log("up");
}

function closeOnClickOutside(modalId, dotNetObjRef) {
    console.log("Click event listener added.");
    document.addEventListener('click', function (event) {
        var modal = document.getElementById(modalId);

        if (!modal.contains(event.target)) {
            dotNetObjRef.invokeMethodAsync('CloseModal');
            console.log("Clicked outside the modal.");
        }
    });
}




window.scrollHandler = function (dotNetHelper) {
    window.onscroll = function () {
        let scrollPosition = window.scrollY || document.documentElement.scrollTop;
        dotNetHelper.invokeMethodAsync('HandleScroll', scrollPosition);
    };
};

window.changeTheme = (themeName) => {
    var link = document.getElementById('theme-link');
    if (link) {
        link.href = `css/theme/${themeName}.css`;
       
    }
    /*location.reload();*/
};
