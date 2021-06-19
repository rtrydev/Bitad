import { Fragment } from "react";
import Navigation from "./components/Navigation/Navigation";
import MainHero from "./components/UI/MainHero";
import TwoColumns from "./components/UI/Columns/TwoColumns";
import ThreeColumns from "./components/UI/Columns/ThreeColumns";
import MainButton from "./components/UI/MainButton";
import Section from "./components/UI/Section";
import DecoratedImage from "./components/UI/DecoratedImage.js";
import Card from "./components/Cards/Card.js";

import bg from "./assets/css/Backgrounds.module.css";
import typography from "./assets/css/Typography.module.css";
import heroImage from "./assets/images/bitad-logo.svg";
import image from "./assets/images/lectures.jpg";

function App() {
  return (
    <Fragment>
      <Navigation />
      <MainHero
        imageSrc={heroImage}
        imageAlt="Logo konferencji"
        subtitle="20 marca 2020, na terenie uczelni ATH w Bielsku-Białej"
        title="Konferencja Informatyczna"
        button={<MainButton text="Zapisz się już dziś" />}
      />
      <main>
        <Section>
          <TwoColumns>
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
            <DecoratedImage src={image} alt="Sala wykładowa ze studentami" />
          </TwoColumns>
        </Section>
        <Section className={bg["half-background"]}>
          <h2 className={typography["text-align--center"]}>
            Możesz się u nas spodziewać*
          </h2>
          <p className={typography["text-align--right"]}>
            *Oczywiście również o wiele, wiele więcej.
          </p>
          <ThreeColumns>
            <Card>123</Card>
            <Card>123</Card>
            <Card>123</Card>
          </ThreeColumns>
        </Section>
      </main>
    </Fragment>
  );
}

export default App;
