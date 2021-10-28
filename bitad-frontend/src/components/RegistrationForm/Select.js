import styles from "./RegistrationFrom.module.css";

export function Select({ name, options = [], errors, register }) {
  const required = "Pole wymagane";
  return (
    <>
      <select
        name={name}
        {...register(name, { required })}
        className={`${styles.field__select} ${
          errors[name] !== undefined && styles["input--error"]
        }`}
      >
        {options.map((option, index) => (
          <option key={index} value={option.value} disabled={option.disabled}>
            {option.label}
          </option>
        ))}
      </select>
      {errors[name] !== undefined && (
        <p className={styles.field__error}>{errors[name]?.message}</p>
      )}
    </>
  );
}
