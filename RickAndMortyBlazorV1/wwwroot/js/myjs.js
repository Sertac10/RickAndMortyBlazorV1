
function scrollToTop() {
        window.scrollTo({
            top: 400,
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





