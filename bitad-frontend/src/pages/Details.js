import SmallHero from "../components/Hero/SmallHero";
import Section from "../components/UI/Section";
import { HashLink } from "react-router-hash-link";

import styles from "./Details.module.css";
import heroImage from "../assets/images/bitad-logo-2022.svg";

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
            ? process.env.REACT_APP_ENABLED_REGISTRATION_LABEL
            : process.env.REACT_APP_DISABLED_REGISTRATION_LABEL
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
          <h2>Starter packi</h2>
          <p>
            Dla każdego uczestnika, który dokona rejestracji na Akademii
            Techniczno-Humanistycznej, czekać będzie pakiet powitalny. Dzięki
            temu będziecie w stanie bardziej zaznajomić się z wydarzeniem,
            agendą oraz nagrodami.
          </p>
        </Section>
        <Section
          className={styles.details__section}
          isSmallSection={true}
          id="workshops"
        >
          <h2>Warsztaty</h2>
          <p>
            Dla osób nie bojących się nowych wyzwań i chcących pogłębić swoje
            umiejętności poprzez praktykę przygotowane zostały warsztaty o
            rozmaitej tematyce pod okiem specjalistów. Każdy znajdzie coś dla
            siebie.
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
            za nie zdobyć 40 i 20 punktów. Zwiększają one Wasze szanse na
            zdobycie wyjątkowych nagród. Losowanie upominków dla szczęściarzy
            odbędzie się od 16:30 do 17:00 podczas konferencji w sali 128
            (Aula).
          </p>
          <p>
            Aplikację do Gry QR na Andrioda można pobrać{" "}
            <a
              href="https://play.google.com/store/apps/details?id=com.reset.Bitad2021"
              target="_blank"
              rel="noreferrer"
            >
              tutaj
            </a>{" "}
            (nie mamy wersji na iOS). Zalogujesz się do niej przy pomocy maila i
            hasła podanego podczas rejestracji na stronie. Zapraszamy do udziału
            w konkursie!
          </p>
        </Section>
      </main>
    </div>
  );
}

export default Details;
