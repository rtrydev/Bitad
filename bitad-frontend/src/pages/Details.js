import SmallHero from "../components/Hero/SmallHero";
import Section from "../components/UI/Section";
import { HashLink } from "react-router-hash-link";

import styles from "./Details.module.css";
import heroImage from "../assets/images/bitad-logo.svg";

function Details() {
  return (
    <div>
      <SmallHero
        imageSrc={heroImage}
        imageAlt="Logo konferencji"
        subtitle="19 listopada 2021, na terenie uczelni ATH w Bielsku-Białej"
        title="Konferencja Informatyczna"
        linkText={
          process.env.REACT_APP_ENABLE_REGISTRATION === "enabled"
            ? "Zapisz się już dziś!"
            : "Rejestracja już wkrótce"
        }
        linkTo={
          process.env.REACT_APP_ENABLE_REGISTRATION === "enabled"
            ? "/registration"
            : "#"
        }
      />
      <main className={styles.details}>
        <Section
          className={styles.details__section}
          isSmallSection={true}
          id="gift"
        >
          <h2>Powitalna paczka</h2>
          <p>
            Dla każdego uczestnika, który dokona rejestracji na Akademii
            Techniczno-Humanistycznej, czekać będzie StartPack, dzięki temu
            będziecie w stanie bardziej zaznajomić się z wydarzeniem, agendą
            oraz nagrodami. Dodatkowo czekać będą na Was niespodzianki w postaci
            długopisów, smyczy i wielu, wielu więcej!
          </p>
        </Section>
        <Section
          className={styles.details__section}
          isSmallSection={true}
          id="workshops"
        >
          <h2>Warsztaty</h2>
          <p>
            Wiemy, że najlepszy sposób nauki to ciągła praktyka i stawianie
            czoła nowym wyzwaniom. Dlatego na warsztatach będziecie w stanie
            pogłębić wiedzę na dany, interesujący Was temat pod okiem
            profesjonalistów. Będzie ciekawie, będą przekąski… zapraszamy!
          </p>
          <p>
            Zapraszamy do wzięcia udziału:{" "}
            <HashLink to="/agenda#agenda">Link do agendy</HashLink>.
          </p>
        </Section>
        <Section
          className={styles.details__section}
          isSmallSection={true}
          id="game"
        >
          <h2>Gra QR Code</h2>
          <p>
            Biorąc udział w warsztatach będziecie mogli zbierać punkty z kodów
            QR, które potem przybliżą Was przy losowaniu do głównej nagrody.
            Punkty będziemy również rozdawać na strefie gier. Serdecznie
            zapraszamy do zabawy.
          </p>
        </Section>
      </main>
    </div>
  );
}

export default Details;
