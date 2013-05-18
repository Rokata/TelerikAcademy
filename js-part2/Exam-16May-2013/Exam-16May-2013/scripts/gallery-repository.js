var imageGalleryRepository = function () {
    function load(key) {
        var data = localStorage.getObject(key);
        return data;
    }

    function save(title, dataObject) {
        localStorage.setObject(title, dataObject);
    }

    return {
        load: load,
        save: save
    }
}();