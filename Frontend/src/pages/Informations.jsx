import React from 'react';
import Container from 'react-bootstrap/Container';
import { FaFacebook } from "react-icons/fa";
import { RiInstagramFill } from "react-icons/ri";
import { FaPhoneAlt } from "react-icons/fa";
import { FaLocationDot } from "react-icons/fa6";
import { IoMdMail } from "react-icons/io";

import './Informations.css'


const MapContainer = () => {
  const iframeStyles = {
    border: 0
  };

  return (
    <Container>
    <div class="karta">
        <p id="gdjeSeNalazimo">GDJE SE NALAZIMO</p>
      <iframe
        width="600"
        height="450"
        loading="lazy"
        allowFullScreen
        src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d1717.6460817018763!2d14.274988212367182!3d45.29855698701983!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1shr!2shr!4v1709323271122!5m2!1shr!2shr"
        title="Google Maps"
        style={iframeStyles}
        referrerPolicy="no-referrer-when-downgrade"
      ></iframe>
    </div>

<div className="kontakt">
<a href="https://www.facebook.com/karlo.kecpeterfaj" target="_blank">
    <FaFacebook />
    <p>Facebook stranica</p>
  </a>
  <a href="https://www.instagram.com/karlo_keco/" target="_blank">
    <RiInstagramFill />
    <p>Instagram stranica</p>
  </a>
  <a href="tel:+123456789" target="_blank">
    <FaPhoneAlt />
    <p>099 475 3526</p>
  </a>
  <a href="https://maps.google.com" target="_blank">
    <FaLocationDot />
    <p>Omladinska 15, 51415, Lovran</p>
  </a>
  <a href="mailto:info@example.com" target="_blank">
    <IoMdMail />
    <p>Karlo.peterfaj@codelab-software.hr</p>
  </a>

</div>
    </Container>
  );
};

export default MapContainer;
