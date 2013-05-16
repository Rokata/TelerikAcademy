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
    }

    function GalleryImage(imageTitle, source) {
        this.title = document.createElement("h4");
        this.title.innerHTML = imageTitle;
        this.image = new Image();
        this.image.src = source;
    }

    function Album(albumTitle) {
        this.images = [];
        this.albums = [];
        this.albumElement = document.createElement("div");
        this.imagesHolder = document.createElement("ul");
        this.albumsHolder = document.createElement("div");
        this.title = document.createElement("h4");

        this.title.addEventListener("click", function () {
            var sibling = this.nextSibling;

            if (!sibling) return false;

            while (sibling) {
                if (sibling.style.display == "none")
                    sibling.style.display = "block";
                else
                    sibling.style.display = "none";

                sibling = sibling.nextSibling;
            }
        });

        this.title.innerHTML = albumTitle;
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

    return {
        getImageGallery: getImageGallery
    };
}();


  
