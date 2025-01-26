
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
        let scrollPosition = Math.min(
           
            parseInt(window.scrollY)
        );

        if (dotNetHelper && dotNetHelper.invokeMethodAsync) {
            dotNetHelper.invokeMethodAsync('HandleScroll', scrollPosition)
                .catch(error => console.error("Blazor calling method error: ", error));
        }
    };
};


window.changeTheme = (themeName) => {
    var link = document.getElementById('theme-link');
    if (link) {
        link.href = `css/theme/${themeName}.css`;
       
    }
    
};

//async function getRandomGoogleImage(searchTerm) {
//    const query = encodeURIComponent(searchTerm);
//    const url = `https://www.google.com/search?tbm=isch&q=${query}`;

//    try {
//        const response = await fetch(url, {
//            method: 'GET',
//            headers: {
//                'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36',
//                'Access-Control-Allow-Origin': '*'
//            },
//            mode: 'no-cors'
//        });

//        const html = await response.text();

//        const parser = new DOMParser();
//        const doc = parser.parseFromString(html, 'text/html');

//        const imgTags = Array.from(doc.querySelectorAll('img'));

//        const firstFiveImages = imgTags.slice(0, 5).map(img => img.src);

//        if (firstFiveImages.length > 0) {
//            const randomIndex = Math.floor(Math.random() * firstFiveImages.length);
//            return firstFiveImages[randomIndex];
//        } else {
//            return "No image found";
//        }
//    } catch (error) {
//        console.error('Error fetching images:', error);
//        return "Error";
//    }
//}

//async function getRandomBingImage(searchTerm) {
//    const query = encodeURIComponent(searchTerm);
//    const url = `https://www.bing.com/images/search?q=${query}`;

//    const response = await fetch(url, {
//        headers: {
//            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3",
//            "Accept-Language": "en-US,en;q=0.5"
//        },
//        mode: 'no-cors'
//    });

//    const htmlText = await response.text();
//    const parser = new DOMParser();
//    const doc = parser.parseFromString(htmlText, "text/html");

//    // img taglerini ve resim URL'lerini alıyoruz
//    const imageNodes = Array.from(doc.querySelectorAll("img.mimg")).map(img => img.src);

//    // İlk 5 resmi alıyoruz
//    const firstFiveImages = imageNodes.slice(0, 5);

//    if (firstFiveImages.length > 0) {
//        const randomIndex = Math.floor(Math.random() * firstFiveImages.length);
//        return firstFiveImages[randomIndex]; // Rastgele bir resim seçiyoruz
//    } else {
//        return "No image found";
//    }
//}




