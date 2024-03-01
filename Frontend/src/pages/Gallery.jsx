import PhotoAlbum from "react-photo-album";
import Container from 'react-bootstrap/Container';
import './Gallery.css';


const photos = [
    { src: "https://picsum.photos/id/1018/800/600", width: 800, height: 600 },
    { src: "https://picsum.photos/id/1015/1600/900", width: 1600, height: 900 },
    { src: "https://picsum.photos/id/1019/800/600", width: 800, height: 600 },
    { src: "https://picsum.photos/id/1020/1600/900", width: 1600, height: 900 },
    { src: "https://picsum.photos/id/1021/800/600", width: 800, height: 600 },
    { src: "https://picsum.photos/id/1022/1600/900", width: 1600, height: 900 },
    { src: "https://picsum.photos/id/1023/800/600", width: 800, height: 600 },
    { src: "https://picsum.photos/id/1024/1600/900", width: 1600, height: 900 },
    { src: "https://picsum.photos/id/1025/800/600", width: 800, height: 600 },
    { src: "https://picsum.photos/id/1026/1600/900", width: 1600, height: 900 }
];

export default function Gallery() {
  return (
    <Container>
        <p class="galerryCss">GALERIJA</p>
      <PhotoAlbum layout="rows" photos={photos} />
    </Container>
  );
}
