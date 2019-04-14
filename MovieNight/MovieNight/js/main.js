$(document).ready(() => {
    $('#createButton').replaceWith('<div id="searchForm"><input type="text" class="form-control mr-sm-2" id="searchText" placeholder="Search Movies..."><button class="btn btn-secondary my-2 my-sm-0" id="Submit1" type="submit">Search</button></div>');

    $('#Submit1').on('click', (e) => {
        $('#movies').empty();
        let searchText = $('#searchText').val();
        getMovies(searchText);
        e.preventDefault();
    });
});

function getMovies(searchText) {

    axios.get('http://www.omdbapi.com?s=' + searchText + '&apikey=b9bb3ece')
        .then((response) => {
            console.log(response);
            let movies = response.data.Search;
            let output = '';
            let count = '';
            $.each(movies, (index, movie) => {

                output += `
          <div class="col-md-3">
            <div class="well text-center">
              <img src="${movie.Poster}">
              <h5>${movie.Title}</h5>
              <a onclick="movieSelected('${movie.imdbID}')" class="btn btn-primary" href="https://www.imdb.com/title/${movie.imdbID}">Link to IMDB</a>
            </div>
          </div>
        `;
            });

            $('#movies').append(output);
        })
        .catch((err) => {
            console.log(err);
        });
}

function movieSelected(id) {
    sessionStorage.setItem('movieId', id);
    window.location = 'movie.html';
    return false;
}

