import Columns from "../../components/UI/Columns";

import styles from "./Registration.module.css";
import bg from "../../assets/css/Backgrounds.module.css";
import registartionImage from "../../assets/images/bitad-logo.svg";
import Section from "../../components/UI/Section";
import RegistrationFrom from "../../components/RegistrationForm/RegistrationFrom";

function Registration() {
  return (
    <main>
      <Section
        className={`${styles.registration} ${bg["registration-background"]}`}
      >
        <Columns className={styles["registration--two-columns"]}>
          <div>
            <h2>Rejestracja na konferencję</h2>
            <h4>20 marca 2020, na terenie uczelni ATH w Bielsku-Białej</h4>
            <p>
              Po zapisaniu się na podany adres email wyślemy Ci potwierdzenie
              rejestracji. Aby wziąć udział w konferencji należy je potwierdzić.
            </p>
            <RegistrationFrom />
          </div>
          <img src={registartionImage} alt="Logo Bitadu" />
        </Columns>
      </Section>
    </main>
  );
}

export default Registration;
