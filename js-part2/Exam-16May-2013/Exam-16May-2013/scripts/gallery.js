var controls = function () {
    function getImageGallery(selector) {
        return new Gallery(selector);
    }

    function Gallery(selector) {
        this.galleryHolder = document.querySelector(selector);
        this.imagesHolder = document.createElement("ul");
        this.galleryHolder.appendChild(this.imagesHolder);
        this.images = [];
        this.albums = [];

        this.addImage = function (imageTitle, imageSource) {
            var galleryImageItem = new GalleryImage(imageTitle, imageSource);
            this.images.push(galleryImageItem);
            var albumItem = document.createElement("li");
            albumItem.className = "album-pic";
            albumItem.appendChild(galleryImageItem.title);
            albumItem.appendChild(galleryImageItem.image);
            this.imagesHolder.appendChild(albumItem);
        }

        this.addAlbum = function (albumTitle) {
            var newAlbum = new Album(albumTitle);
            this.albums.push(newAlbum);
            this.galleryHolder.appendChild(newAlbum.albumElement);
            return newAlbum;
        }

        this.getImageGalleryData = function () {
            var galleryData = serializeData(gallery);
            return galleryData;
        }

        function serializeData(gallery) {
            var thisItem = {
                title: "",
                imagesInfo: [],
                albums: []
            }

            if (gallery.title) {
                thisItem.title = gallery.title.innerHTML;
            }

            for (var i = 0; i < gallery.images.length; i++) {
                var imageTitle = gallery.images[i].title.innerHTML;
                var imageSource = gallery.images[i].image.src;

                thisItem.imagesInfo.push({ title: imageTitle, source: imageSource });
            }

            for (var i = 0; i < gallery.albums.length; i++) {
                var currentAlbum = gallery.albums[i];
                thisItem.albums.push(serializeData(currentAlbum));
            }

            return thisItem;
        }
    }

    function GalleryImage(imageTitle, source) {
        this.title = document.createElement("h4");
        this.title.appendChild(document.createTextNode(imageTitle));
        this.image = new Image();
        this.image.src = source;

        this.image.onclick = function (ev) {
            var holder = document.getElementById("zoomed-img-area");

            if (holder.childElementCount != 0) {
                holder.removeChild(holder.firstChild)
            }

            var zoomedImg = ev.target.cloneNode(true);
            holder.appendChild(zoomedImg);
            var originalWidth = parseInt(window.getComputedStyle(ev.target, null).getPropertyValue("width"));
            var originalHeight = parseInt(window.getComputedStyle(ev.target, null).getPropertyValue("height"));
            zoomedImg.style.width = (originalWidth * 2) + 'px';
            zoomedImg.style.height = (originalHeight * 2) + 'px';
        }
    }

    function Album(albumTitle) {
        this.images = [];
        this.albums = [];
        this.albumElement = document.createElement("div");
        this.imagesHolder = document.createElement("ul");
        this.albumsHolder = document.createElement("div");
        this.title = document.createElement("h4");

        this.title.onclick = function () {
            var sibling = this.nextSibling;

            if (!sibling) return false;

            while (sibling) {
                if (sibling.style.display == "none")
                    sibling.style.display = "block";
                else
                    sibling.style.display = "none";

                sibling = sibling.nextSibling;
            }
        };

        this.title.appendChild(document.createTextNode(albumTitle));
        this.title.className = "album-title";
        this.albumsHolder.className = "albums-holder";
        this.albumElement.appendChild(this.title);
        this.albumElement.appendChild(this.imagesHolder);
        this.albumElement.appendChild(this.albumsHolder);

        this.addImage = function (imageTitle, imageSource) {
            var galleryImageItem = new GalleryImage(imageTitle, imageSource);
            this.images.push(galleryImageItem);
            var albumItem = document.createElement("li");
            albumItem.className = "album-pic";
            albumItem.appendChild(galleryImageItem.title);
            albumItem.appendChild(galleryImageItem.image);
            this.imagesHolder.appendChild(albumItem);
        }

        this.addAlbum = function (albumTitle) {
            var newAlbum = new Album(albumTitle);
            this.albums.push(newAlbum);
            this.albumsHolder.appendChild(newAlbum.albumElement);
            return newAlbum;
        }
    }

    function buildImageGallery(selector, data) {
        var gallery = new Gallery(selector);
        deserializeData(gallery, data);
        return gallery;
    }

    function deserializeData(item, data) {
        for (var i = 0; i < data.imagesInfo.length; i++) {
            var imageInfo = data.imagesInfo[i];
            item.addImage(imageInfo.title, imageInfo.source);
        }
       
        for (var i = 0; i < data.albums.length; i++) {
            var album = item.addAlbum(data.albums[i].title);
            deserializeData(album, data.albums[i]);
        }

        return item;
    }

    return {
        getImageGallery: getImageGallery,
        buildImageGallery: buildImageGallery
    };
}();



