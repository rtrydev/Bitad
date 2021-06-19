import { Fragment } from "react";
import Navigation from "./components/Navigation/Navigation";
import MainHero from "./components/MainHero";
import TwoColumns from "./components/TwoColumns";
import MainButton from "./components/UI/MainButton";
import DecoratedImage from "./components/DecoratedImage.js";
import heroImage from "./assets/images/bitad-logo.svg";
import image from "./assets/images/lectures.jpg";

const firstColumnChildren = (
  <Fragment>
    <h2>
      Spotykamy się już <br />
      kolejny, 10 raz
    </h2>
    <p>
      Podjęliśmy się organizacji konferencji Beskid IT Academic Day na Akademii
      Techniczno-Humanistycznej w Bielsku-Białej.
    </p>
    <p>
      Nieustannie staramy się rozwijać nasz event, jednocześnie dbając o to, aby
      uczestnicy, zarówno profesjonaliści, jak i amatorzy, wynieśli z tego dnia
      ogromne pokłady wiedzy.
    </p>
    <p>
      Jak i motywacji do jej dalszego poszerzania. Dodatkowo dbamy o to, aby to
      piątkowe spotkanie.
    </p>
  </Fragment>
);

const secondColumnChildren = (
  <DecoratedImage src={image} alt="Sala wykładowa ze studentami" />
);

function App() {
  return (
    <Fragment>
      <Navigation />
      <MainHero
        heroImage={heroImage}
        subtitle="20 marca 2020, na terenie uczelni ATH w Bielsku-Białej"
        title="Konferencja Informatyczna"
        button={<MainButton text="Zapisz się już dziś" />}
      />
      <main>
        <TwoColumns
          firstColumnChildren={firstColumnChildren}
          secondColumnChildren={secondColumnChildren}
        />
      </main>
    </Fragment>
  );
}

export default App;
