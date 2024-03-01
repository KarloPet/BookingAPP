import React from 'react';
import Container from 'react-bootstrap/Container';
import ImageGallery from "react-image-gallery";
import "./Pocetna.css"

const images = [
  {
    original: "https://picsum.photos/id/1018/1000/600/",
    thumbnail: "https://picsum.photos/id/1018/250/150/",
  },
  {
    original: "https://picsum.photos/id/1015/1000/600/",
    thumbnail: "https://picsum.photos/id/1015/250/150/",
  },
  {
    original: "https://picsum.photos/id/1019/1000/600/",
    thumbnail: "https://picsum.photos/id/1019/250/150/",
  },
];



function MyGallery() {
  return (
    <Container>
        <div className="naslov"><h1>
            apartmani peterfaj
        </h1>
        </div>

      <ImageGallery items={images} 
      showPlayButton={false}
      showFullscreenButton={false}
      />

    </Container>
  );
}

export default MyGallery;
