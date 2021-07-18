import styles from "./RegistrationFrom.module.css";

export function FormTextInput({ register, name, errors, ...rest }) {
  const maxLength = { value: 50, message: "Maksymalnie 50 znaków" };
  const minLength = { value: 3, message: "Minimum 3 znaki" };
  const required = "Pole wymagane";
  return (
    <div className={styles.section__field}>
      <label htmlFor={name}>{rest.labelText}</label>
      <input
        id={name}
        {...register(name, { required, minLength, maxLength })}
        type={rest.type ? rest.type : "text"}
        className={styles.field__input}
      />
      {errors[name] !== undefined && (
        <p className={styles.field__error}>{errors[name]?.message}</p>
      )}
    </div>
  );
}
