import { Fragment } from "react";
import MainHero from "../components/UI/MainHero";
import Columns from "../components/UI/Columns";
import MainButton from "../components/UI/MainButton";
import Section from "../components/UI/Section";
import DecoratedImage from "../components/UI/DecoratedImage.js";
import ImageWithShadow from "../components/UI/ImageWithShadow.js";
import SimpleCard from "../components/Cards/SimpleCard.js";
import Sponsors from "../components/Sponsors/Sponsors";

import bg from "../assets/css/Backgrounds.module.css";
import typography from "../assets/css/Typography.module.css";
import heroImage from "../assets/images/bitad-logo.svg";
import decoratedImage from "../assets/images/lectures.jpg";
import giftIcon from "../assets/images/gift.svg";
import keyboardIcon from "../assets/images/keyboard.svg";
import gamepadIcon from "../assets/images/gamepad.svg";
import workshopImage from "../assets/images/workshop.jpg";

function About() {
  return (
    <Fragment>
      <MainHero
        imageSrc={heroImage}
        imageAlt="Logo konferencji"
        subtitle="20 marca 2020, na terenie uczelni ATH w Bielsku-Białej"
        title="Konferencja Informatyczna"
        button={<MainButton text="Zapisz się już dziś" />}
      />
      <main>
        <Section>
          <Columns>
            <div>
              <h2>
                Spotykamy się już <br />
                kolejny, 10 raz
              </h2>
              <p>
                Podjęliśmy się organizacji konferencji Beskid IT Academic Day na
                Akademii Techniczno-Humanistycznej w Bielsku-Białej.
              </p>
              <p>
                Nieustannie staramy się rozwijać nasz event, jednocześnie dbając
                o to, aby uczestnicy, zarówno profesjonaliści, jak i amatorzy,
                wynieśli z tego dnia ogromne pokłady wiedzy.
              </p>
              <p>
                Jak i motywacji do jej dalszego poszerzania. Dodatkowo dbamy o
                to, aby to piątkowe spotkanie.
              </p>
            </div>
            <DecoratedImage
              src={decoratedImage}
              alt="Sala wykładowa ze studentami"
            />
          </Columns>
        </Section>
        <Section className={bg["half-background"]}>
          <h2 className={typography["text-align--center"]}>
            Możesz się u nas spodziewać*
          </h2>
          <p className={typography["text-align--right"]}>
            *Oczywiście również o wiele, wiele więcej.
          </p>
          <Columns columns="3.5">
            <SimpleCard
              title="Powitalnej paczki"
              description="Dlatego każdy z Was zaraz po potwierdzeniu swojej obecności na konferencji będzie czekała powitalna paczka."
              image={{ src: giftIcon, alt: "Ikona prezentu" }}
              link="/description"
            />
            <SimpleCard
              title="Warsztatów"
              description="Warsztaty mają na celu zaprezentowanie podstaw tematów będących na czasie w praktyce."
              image={{ src: keyboardIcon, alt: "Ikona klawiatury" }}
              link="/description"
            />
            <SimpleCard
              title="Gry QR Code"
              description="Baw się z nami i zdobywaj punkty podczas udziału w prelekcjach i warsztatach. "
              image={{ src: gamepadIcon, alt: "Ikona pada do gier" }}
              link="/description"
            />
          </Columns>
        </Section>
        <Section className={typography["text-align--center"]}>
          <h2>Ciągle rozwijamy się dla Ciebie</h2>
          <p>
            Jak i motywacji do jej dalszego poszerzania. Dodatkowo dbamy o to,
            aby to piątkowe spotkanie było przede wszystkim. Mile spędzonym
            czasem, dlatego wzbogaciliśmy konferencję o dodatkowe atrakcje.
          </p>
          <ImageWithShadow
            src={workshopImage}
            alt="Sala komputerowa z pracującymi uczniami"
            className={bg.shadow}
            maxWidth="900px"
          />
        </Section>
        <Section>
          <Columns>
            <Sponsors />
            <div>
              <h2>Konferencja jest możliwa dzięki Nim!</h2>
              <p>
                Podjęliśmy się organizacji konferencji Beskid IT Academic Day na
                Akademii Techniczno-Humanistycznej w Bielsku-Białej.
              </p>
              <p>
                Nieustannie staramy się rozwijać nasz event, jednocześnie dbając
                o to, aby uczestnicy, zarówno profesjonaliści, jak i amatorzy,
                wynieśli z tego dnia ogromne pokłady wiedzy.
              </p>
              <p>
                Jak i motywacji do jej dalszego poszerzania. Dodatkowo dbamy o
                to, aby to piątkowe spotkanie.
              </p>
            </div>
          </Columns>
        </Section>
      </main>
    </Fragment>
  );
}

export default About;
