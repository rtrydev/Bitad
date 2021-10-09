import typography from "../../assets/css/Typography.module.css";
import styles from "./RegistrationFrom.module.css";

function SubmitButton({ children }) {
  return (
    <div className={styles.form__submit}>
      <button className={`${typography.button} ${styles.form__button}`}>
        {children}
      </button>
    </div>
  );
}

export default SubmitButton;
