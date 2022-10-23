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
import heroImage from "../../assets/images/bitad-logo-2022.svg";
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
              <h2>To już 11 edycja eventu…</h2>
              <p>
                Już po raz jedenasty podjęliśmy się organizacji konferencji
                Beskid IT Academic Day na Akademii Techniczno-Humanistycznej w
                Bielsku-Białej. Nieustannie staramy się rozwijać nasz event.
              </p>
              <p>
                Jak co roku zadbamy o to, aby każdy uczestnik zarówno
                profesjonalista jak i amator wyniósł z dnia konferencji ogromne
                pokłady wiedzy i motywacji do dalszego jej zgłębiania oraz miło
                spędził czas korzystając z bogatych atrakcji, które co roku
                staramy się poszerzać.
              </p>
              <p>
                Tegoroczny event - „MaszynoweLove BITAD w chmurach” nawiązywać
                będzie do tematyki Sieci, Chmur, Cyberbezpieczeństwa oraz
                Machine Learningu. BITAD to nie tylko event, gdzie można
                porozmawiać ze specjalistami z całej Polski, ale również spędzić
                mile czas korzystając z wielu różnych atrakcji.
              </p>
            </div>
            <DecoratedImage
              src={decoratedImage}
              alt="Sala wykładowa ze studentami"
            />
          </Columns>
        </Section>
        <Section className={bg["half-background"]}>
          <h2 className={typography["text-align--center"]}>Czekają na was*</h2>
          <p className={typography["text-align--right"]}>
            *oraz wiele innych atrakcji
          </p>
          <Columns columns="3.5">
            <SimpleCard
              title="Starter packi"
              description="Na każdego z Was po potwierdzeniu rejestracji online będzie czekała powitalna paczka w dniu konferencji."
              image={{ src: giftIcon, alt: "Ikona prezentu" }}
              link="/details#gift"
            />
            <SimpleCard
              title="Warsztaty"
              description="Biorąc udział w warsztatach będziesz mógł w praktyce rozwinąć się w wybranym temacie pod okiem profesjonalistów."
              image={{ src: keyboardIcon, alt: "Ikona klawiatury" }}
              link="/details#workshops"
            />
            <SimpleCard
              title="Gra QR Code"
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
          <h2>Ciągły rozwój to nasz priorytet</h2>
          <p>
            Dbamy, aby pobyt na konferencji był dla Was ciekawym wydarzeniem i
            mile spędzonym czasem, więc oprócz dawki wiedzy w postaci prelekcji
            i warsztatów oferujemy również rozluźnienie na strefie gier,
            zjedzenie czegoś smacznego. Ponadto uczestniczenie w grze QR Code
            doda Wam szczęścia przy losowaniu nagród.
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
