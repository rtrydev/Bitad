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
        subtitle="20 marca 2020, na terenie uczelni ATH w Bielsku-Białej"
        title="Konferencja Informatyczna"
        linkText="Zapisz się już dziś!"
        linkTo="/registration"
      />
      <main className={styles.details}>
        <Section className={styles.details__section} isSmallSection={true}>
          <h2>Powitalna paczka</h2>
          <p>
            Podjęliśmy się organizacji konferencji Beskid IT Academic Day na
            Akademii Techniczno-Humanistycznej w Bielsku-Białej. Nieustannie
            staramy się rozwijać nasz event, jednocześnie dbając o to, aby
            uczestnicy, zarówno profesjonaliści, jak i amatorzy, wynieśli z tego
            dnia ogromne pokłady wiedzy.
          </p>
          <p>
            Jak i motywacji do jej dalszego poszerzania. Dodatkowo dbamy o to,
            aby to piątkowe spotkanie. Podjęliśmy się organizacji konferencji
            Beskid IT Academic Day na Akademii Techniczno-Humanistycznej w
            Bielsku-Białej. Nieustannie staramy się rozwijać nasz event,
            jednocześnie dbając.
          </p>
          <h3>Między innymi</h3>
          <ul>
            <li>
              Zaopatrzysz się w koszulkę o rozmiarze jaki wybierzesz podczas
              rejestracji (s/m/l/xl/xxl).
            </li>
            <li>
              Możesz się spodziewać wielu różności i ciekawych rzeczy jak
              zeszytu, długopisów lub nawet smyczy.
            </li>
            <li>
              Nieustannie staramy się rozwijać nasz event, jednocześnie dbając.
            </li>
          </ul>
        </Section>
        <Section className={styles.details__section} isSmallSection={true}>
          <h2>Warsztaty</h2>
          <p>
            Podjęliśmy się organizacji konferencji Beskid IT Academic Day na
            Akademii Techniczno-Humanistycznej w Bielsku-Białej. Nieustannie
            staramy się rozwijać nasz event, jednocześnie dbając o to, aby
            uczestnicy, zarówno profesjonaliści, jak i amatorzy, wynieśli z tego
            dnia ogromne pokłady wiedzy. Jak i motywacji do jej dalszego
            poszerzania. Dodatkowo dbamy o to, aby to piątkowe spotkanie.
          </p>
          <HashLink to="/agenda#agenda">Link do agendy</HashLink>
        </Section>
        <Section className={styles.details__section} isSmallSection={true}>
          <h2>Gra QR Code</h2>
          <p>
            Podjęliśmy się organizacji konferencji Beskid IT Academic Day na
            Akademii Techniczno-Humanistycznej w Bielsku-Białej. Nieustannie
            staramy się rozwijać nasz event, jednocześnie dbając o to, aby
            uczestnicy, zarówno profesjonaliści, jak i amatorzy, wynieśli z tego
            dnia ogromne pokłady wiedzy. Jak i motywacji do jej dalszego
            poszerzania. Dodatkowo dbamy o to, aby to piątkowe spotkanie.
          </p>
        </Section>
      </main>
    </div>
  );
}

export default Details;
