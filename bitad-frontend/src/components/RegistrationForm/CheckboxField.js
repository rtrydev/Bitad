import styles from "./RegistrationFrom.module.css";

export function CheckboxField({ register, name, errors, ...rest }) {
  const required = "Pole wymagane";
  return (
    <div
      className={`${styles.section__field} ${styles["section__field--checkbox"]}`}
    >
      <input
        id={name}
        type="checkbox"
        className={styles.field__checkbox}
        {...register(name, { required })}
      />
      <label htmlFor={name}>{rest.text}</label>
      {errors[name] !== undefined && (
        <p className={styles.field__error}>{errors[name]?.message}</p>
      )}
    </div>
  );
}
