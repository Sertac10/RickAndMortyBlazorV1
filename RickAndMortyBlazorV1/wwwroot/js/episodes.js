
function getSeason(number){
    let season;

    if ( number <= 11 ) season = 'season1';
    else if( number >=12 && number <= 21 ) season = 'season2';
    else if( number >=22 && number <= 31 ) season = 'season3';
    else if( number >=32 && number <= 41 ) season = 'season4';
    else if( number >=42 && number <= 51 ) season = 'season5';

    return season;
}

async function fetchEpisodes(){
    const p1 = fetch('https://rickandmortyapi.com/api/episode?page=1');
    const p2 = fetch('https://rickandmortyapi.com/api/episode?page=2');
    const p3 = fetch('https://rickandmortyapi.com/api/episode?page=3');
    
    let results = await Promise.all([p1,p2,p3]); 
    
    let aux1  = await results[0].json();
    let aux2  = await results[1].json();
    let aux3  = await results[2].json();

    let episodes = aux1.results.concat(aux2.results, aux3.results);

    episodes.forEach(episode => {
        let div = createEpisode(episode);
        let season = getSeason(episode.id);
        document.querySelector(`#${season}`).appendChild(div);
    })  

    renderPagination();
}

function createEpisode (episode){
    let div = document.createElement('div');
    div.classList.add('episode');

    div.innerHTML = `
        <img src="./assets/episodes/${episode.id}.jpg" alt="${episode.id}">
        <p>E${episode.id}: ${episode.name}</p>
    `;
    return div;
}


function renderPagination(){
    const containerCarousels = document.querySelectorAll('.carousel');
    containerCarousels.forEach( (e) => {
       
        let carousel = e.parentElement;
        let season = e.attributes.id.nodeValue;
        const numberPages = Math.ceil(e.childElementCount/5);
        
    
        for( let i = 0 ; i < numberPages; i++){
    
            const indicator = document.createElement('div');
            
            if (i === 0) indicator.classList.add('active');
        
            document.querySelector(`div[data-season='${season}'] .indicators`).appendChild(indicator);
            indicator.addEventListener('click', (ind) => {
                carousel.scrollLeft = i* carousel.offsetWidth;
                document.querySelector(`div[data-season='${season}'] .indicators .active`).classList.remove('active');
                ind.target.classList.add('active');
            });
        }   
    });
}