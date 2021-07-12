import styles from "./RegistrationFrom.module.css";
import { Link } from "react-router-dom";
import typography from "../../assets/css/Typography.module.css";

const FormTextInput = (props) => {
  return (
    <div className={styles.section__field}>
      <label htmlFor={props.name}>{props.labelText}</label>
      <input
        id={props.name}
        type={props.inputType ? props.inputType : "text"}
        className={styles.field__input}
      />
    </div>
  );
};

const FieldWrapper = (props) => {
  return <div className={styles["form__field-wrapper"]}>{props.children}</div>;
};

const CheckboxField = (props) => {
  return (
    <div
      className={`${styles.section__field} ${styles["section__field--checkbox"]}`}
    >
      <input
        id={props.name}
        type="checkbox"
        className={styles.field__checkbox}
      />
      <label htmlFor={props.name}>{props.text}</label>
    </div>
  );
};

function RegistrationFrom() {
  return (
    <form className={styles.form}>
      <div className={styles.form__section}>
        <FieldWrapper>
          <FormTextInput labelText="Imię" name="firstName" />
          <FormTextInput labelText="Nazwisko" name="lastName" />
        </FieldWrapper>
        <FormTextInput labelText="Adres email" name="email" inputType="email" />
        <FormTextInput
          labelText={
            <>
              Hasło do <Link to="/">aplikacji QR Code</Link>
            </>
          }
          name="password"
          inputType="password"
        />
        <FormTextInput
          labelText="Powtórz hasło"
          name="repeatedPassword"
          inputType="password"
        />
      </div>
      <div>
        <CheckboxField
          name="terms1"
          text={
            <>
              Zapoznałem/am się z <Link to="/">Polityką Prywatności</Link> oraz
              z <Link to="/">Regulaminem</Link>.*
            </>
          }
        />
        <CheckboxField
          name="terms2"
          text="Wyrażam zgodę na przetwarzanie moich danych osobowych dla potrzeb niezbędnych do udziału w konferencji.*"
        />
      </div>
      <button className={`${typography.button} ${styles.form__button}`}>
        Zapisz się
      </button>
    </form>
  );
}
export default RegistrationFrom;
