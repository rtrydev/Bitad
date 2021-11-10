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
        subtitle={process.env.REACT_APP_SUBTITLE}
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
            Techniczno-Humanistycznej, czekać będzie pakiet powitalny, dzięki
            temu będziecie w stanie bardziej zaznajomić się z wydarzeniem,
            agendą oraz nagrodami. Dodatkowo czekać będą na Was niespodzianki w
            postaci długopisów, smyczy i wielu, wielu więcej!
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
            profesjonalistów. Będzie ciekawie, będą przekąski… Zapraszamy!
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
            Skanujcie kody QR na warsztatach oraz prelekcjach. Kolejno możecie
            za nie zdobyć 40 i 20pkt, które zwiększają Wasze szanse na zdobycie
            wyjątkowych nagród, w tym nawet Xboxa One X. Losowanie upominków dla
            szczęściarzy odbędzie się o godzinie 16:15 - 16:45 w sali 128
            (Aula).
          </p>
          <p>
            Aplikacje do gry można pobrać podczas konferencji z Google Play.
            Zalogujesz się do niej przy pomocy maila i hasła podanego przy
            rejestracji. Zapraszamy do udziału w konkursie!
          </p>
        </Section>
      </main>
    </div>
  );
}

export default Details;
