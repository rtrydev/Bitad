import styles from "./RegistrationFrom.module.css";

export function FormEmailInput({ register, name, errors, ...rest }) {
  const pattern = {
    value:
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    message: "Niewłaściwy adres email",
  };
  const required = "Pole wymagane";
  return (
    <div className={styles.section__field}>
      <label htmlFor={name}>{rest.labelText}</label>
      <input
        id={name}
        {...register(name, { required, pattern })}
        type="email"
        className={styles.field__input}
      />
      {errors[name] !== undefined && (
        <p className={styles.field__error}>{errors[name]?.message}</p>
      )}
    </div>
  );
}
