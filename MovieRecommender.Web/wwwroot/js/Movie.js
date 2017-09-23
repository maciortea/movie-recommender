var Movie = function () {
    var movies = {};
    var searchQuery;

    var addMovieByTitle = function (title) {
        if (movies[title]) {
            var $li = $('<li class="list-group-item"></li>');
            $li.attr('data-movie-id', movies[title]);
            $li.text(title);
            var $removeLink = $('<a href="javascript:void(0)" class="pull-right remove"><span class="glyphicon glyphicon-remove"></span></a>');
            $li.append($removeLink);
            $('#SelectedMovies').append($li);
        }
    };

    var init = function () {
        $('#SelectedMovies').on('click', '.remove', function () {
            $(this).parent('li').remove();
        });

        $('#SearchMovie').typeahead({
            source: function (query, process) {
                return $.get('/Movie/GetMovies', { query: query }, function (data) {
                    searchQuery = query;

                    for (var i = 0; i < data.length; i++) {
                        movies[data[i].name] = data[i].id;
                    }

                    return process(data);
                });
            },
            highlighter: function (item) {
                var regex = new RegExp('(' + searchQuery + ')', 'ig');
                text = item.replace(regex, '<strong>$1</strong>');
                return text;
            },
            delay: 500,
            items: 10
        });

        $('#SearchMovie').change(function () {
            if (searchQuery && $(this).val() !== searchQuery) {
                addMovieByTitle($(this).val());
                $(this).val('');
            }
        });

        $('a.recommend').click(function () {
            var $btn = $(this);
            if ($btn.attr('disabled') === 'disabled') {
                return;
            }

            $btn.attr('disabled', 'disabled');

            var selectedMovieIds = [];
            $("#SelectedMovies li").each(function () {
                selectedMovieIds.push(parseInt($(this).attr('data-movie-id')));
            });

            $.post('/Movie/GetRecommendedMovies', { preferredMovieIds: selectedMovieIds }, function (res) {
                $btn.attr('disabled', null);

                var $tbl = $('#RecommendedMovies');
                $tbl.find('tr').remove();
                $.each(res, function () {
                    var $tr = $('<tr><td class="title"><b/></td></tr>');
                    var $a = $tr.find('td.title b');
                    $a.text(this.movieTitle);
                    $tbl.append($tr);
                });
                $('#RecommendedMoviesDialog').modal();
            });
        });
    };

    return {
        init: init
    };
}();
