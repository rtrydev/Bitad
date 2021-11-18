import { Fragment } from "react";
import MainHero from "../../components/Hero/MainHero";
import Columns from "../../components/UI/Columns";
import Section from "../../components/UI/Section";
import DecoratedImage from "../../components/UI/DecoratedImage.js";
import ImageWithShadow from "../../components/UI/ImageWithShadow.js";
import SimpleCard from "../../components/Cards/SimpleCard.js";
import SponsorsPart from "./SponsorsPart";
import StaffPart from "./StaffPart";

import bg from "../../assets/css/Backgrounds.module.css";
import typography from "../../assets/css/Typography.module.css";
import heroImage from "../../assets/images/bitad-logo.svg";
import decoratedImage from "../../assets/images/lectures.jpg";
import giftIcon from "../../assets/images/gift.svg";
import keyboardIcon from "../../assets/images/keyboard.svg";
import gamepadIcon from "../../assets/images/gamepad.svg";
import workshopImage from "../../assets/images/workshop.jpg";

function About() {
  return (
    <Fragment>
      <MainHero
        imageSrc={heroImage}
        imageAlt="Logo konferencji"
        subtitle={process.env.REACT_APP_SUBTITLE}
        title="Konferencja Informatyczna"
        linkText={
          process.env.REACT_APP_ENABLE_REGISTRATION === "enabled"
            ? process.env.REACT_APP_ENABLED_REGISTRATION_LABEL
            : process.env.REACT_APP_DISABLED_REGISTRATION_LABEL
        }
        linkTo={
          process.env.REACT_APP_ENABLE_REGISTRATION === "enabled"
            ? "/registration"
            : "#"
        }
      />
      <main>
        <Section>
          <Columns>
            <div>
              <h2>Powrót do przeszłości…</h2>
              <p>
                Przez pandemię ominęła nas rok temu nauka i dobra zabawa, więc
                tym bardziej inkrementacyjna edycja 2020++ konferencji jest
                wyjątkowa. Powracamy jeszcze bardziej zmotywowani do działania
                przy organizacji Beskid IT Academic Day na Akademii
                Techniczno-Humanistycznej w Bielsku-Białej.
              </p>
              <p>
                Zadbaliśmy, aby każdy uczestnik wyniósł z tego dnia ogromne
                pokłady wiedzy oraz motywacji do dalszego rozwijania się,
                poprzez liczne warsztaty oraz wykłady.
              </p>
              <p>
                Dbamy również, aby spędzony czas z nami był jak najlepiej
                spożytkowany.
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
              description="Na każdego z Was po potwierdzeniu rejestracji online będzie czekała powitalna paczka w dniu konferencji."
              image={{ src: giftIcon, alt: "Ikona prezentu" }}
              link="/details#gift"
            />
            <SimpleCard
              title="Warsztatów"
              description="Biorąc udział w warsztatach będziesz mógł w praktyce rozwinąć się w wybranym temacie pod okiem profesjonalistów."
              image={{ src: keyboardIcon, alt: "Ikona klawiatury" }}
              link="/details#workshops"
            />
            <SimpleCard
              title="Gry QR Code"
              description={
                <>
                  Baw się z nami i zdobywaj punkty podczas udziału w prelekcjach
                  i warsztatach. Aplikację do Gry QR na Andrioda możesz pobrać{" "}
                  <a
                    href="https://play.google.com/store/apps/details?id=com.reset.Bitad2021"
                    target="_blank"
                    rel="noreferrer"
                  >
                    tutaj
                  </a>
                  .
                </>
              }
              image={{ src: gamepadIcon, alt: "Ikona pada do gier" }}
              link="/details#game"
            />
          </Columns>
        </Section>
        <Section className={typography["text-align--center"]}>
          <h2>Ciągle rozwijamy się dla Ciebie</h2>
          <p>
            Dbamy o to, aby to piątkowe spotkanie było przede wszystkim mile
            spędzonym czasem. Dlatego nie zapominając, że nauka to potęgi klucz,
            powinniśmy znaleźć również czas na relaks. Stworzyliśmy więc strefę
            gier komputerowych i planszowych. Każdy znajdzie coś dla siebie,
            przyjemnie pożytkując czas.
          </p>
          <ImageWithShadow
            src={workshopImage}
            alt="Sala komputerowa z pracującymi uczniami"
            className={bg.shadow}
            maxWidth="900px"
          />
        </Section>
        <Section id="sponsors" className={bg["neutral-background"]}>
          <SponsorsPart />
        </Section>
        <Section>
          <StaffPart />
        </Section>
      </main>
    </Fragment>
  );
}

export default About;
