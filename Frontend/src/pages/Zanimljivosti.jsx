import React from 'react';
import Container from 'react-bootstrap/Container';
import ImageGallery from "react-image-gallery";
import "./Zanimljivosti.css"

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
        <p class="naslov2">
          ZANIMLJIVOSTI
        </p>
      <ImageGallery items={images} 
            showPlayButton={false}
            showFullscreenButton={false}
      />
      <div className="informacije">
          <p>
          Lovran, slikoviti gradić na istočnoj obali Jadranskog mora, poznat je po svojoj bogatoj povijesti
          i prekrasnom prirodnom okruženju. Nalazi se u blizini Opatije, poznatog turističkog odredišta. Lovran je poznat po
          svojim starim gradskim jezgrama, uskim ulicama, tradicionalnoj arhitekturi te prekrasnoj prirodi koja ga okružuje, uključujući šetnice duž obale i prekrasne
          plaže. Osim toga, Lovran je poznat po svojim festivalima, poput Festivala maruna, tradicionalne jesenske manifestacije
          posvećene marunima (kestenima), koji su važan simbol grada.
        </p>
      </div>
    </Container>
  );
}

export default MyGallery;
