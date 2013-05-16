var imageGalleryRepository = function () {
    function load(key) {
        var data = localStorage.getObject(key);
        return data;
    }

    function save(title, dataObject) {
        localStorage.setObject(title, dataObject);
    }

    function serializeData(gallery) {
        var thisItem = {
            title: "",
            imagesInfo: [],
            albums: []
        }

        if (gallery.title) {
            thisItem.title = gallery.title;
        }

        for (var i = 0; i < gallery.images.length; i++) {
            thisItem.imagesInfo.push(gallery.images[i]);
        }

        for (var i = 0; i < gallery.albums.length; i++) {
            var currentAlbum = gallery.albums[i];
            thisItem.albums.push(serializeData(currentAlbum));
        }

        return thisItem;
    }
}();