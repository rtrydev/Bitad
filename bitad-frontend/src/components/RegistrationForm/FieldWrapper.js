import styles from "./RegistrationFrom.module.css";

export function FieldWrapper(props) {
  return <div className={styles["form__field-wrapper"]}>{props.children}</div>;
}
