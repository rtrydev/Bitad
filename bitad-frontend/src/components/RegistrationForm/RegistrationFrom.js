import styles from "./RegistrationFrom.module.css";
import { Link } from "react-router-dom";
import typography from "../../assets/css/Typography.module.css";
import { CheckboxField } from "./CheckboxField";
import { FieldWrapper } from "./FieldWrapper";
import { useForm } from "react-hook-form";

const Input = ({ name, errors, register, type, validate }) => {
  const maxLength = { value: 50, message: "Maksymalnie 50 znaków" };
  const minLength = { value: 3, message: "Minimum 3 znaki" };
  const required = "Pole wymagane";
  return (
    <>
      <input
        type={type ? type : "text"}
        {...register(name, { required, minLength, maxLength, validate })}
        className={styles.field__input}
      />
      {errors[name] !== undefined && (
        <p className={styles.field__error}>{errors[name]?.message}</p>
      )}
    </>
  );
};
const InputEmail = ({ name, errors, register }) => {
  const required = "Pole wymagane";
  const pattern = {
    value:
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    message: "Niewłaściwy adres email",
  };
  return (
    <>
      <input
        {...register(name, { required, pattern })}
        type="email"
        className={styles.field__input}
      />
      {errors[name] !== undefined && (
        <p className={styles.field__error}>{errors[name]?.message}</p>
      )}
    </>
  );
};

const FildInput = ({ name, labelText, ...rest }) => {
  return (
    <div className={styles.section__field}>
      <label htmlFor={name}>{labelText}</label>
      {rest.children}
    </div>
  );
};

function RegistrationFrom() {
  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    reset({});
  };
  return (
    <form className={styles.form} onSubmit={handleSubmit(onSubmit)} noValidate>
      <div className={styles.form__section}>
        <FieldWrapper>
          <FildInput name="password" labelText="Imię*">
            <Input register={register} errors={errors} name="firstName" />
          </FildInput>
          <FildInput name="password" labelText="Nazwisko*">
            <Input register={register} errors={errors} name="lastName" />
          </FildInput>
        </FieldWrapper>
        <FildInput name="email" labelText="Adres email">
          <InputEmail register={register} errors={errors} name="email" />
        </FildInput>
        <FildInput
          name="password"
          labelText={
            <>
              Hasło do <Link to="/">aplikacji QR Code</Link>*
            </>
          }
        >
          <Input register={register} errors={errors} name="password" />
        </FildInput>
        <FildInput name="repeatedPassword" labelText="Powtórz hasło">
          <Input
            name="repeatedPassword"
            register={register}
            validate={{
              checkIfEquole: (value) =>
                value === getValues("password") || "Hasła nie są takie same",
            }}
            errors={errors}
          />
        </FildInput>
      </div>
      <div>
        <CheckboxField
          name="terms1"
          register={register}
          text={
            <>
              Zapoznałem/am się z <Link to="/">Polityką Prywatności</Link> oraz
              z <Link to="/">Regulaminem</Link>.*
            </>
          }
          errors={errors}
        />
        <CheckboxField
          name="terms2"
          register={register}
          text="Wyrażam zgodę na przetwarzanie moich danych osobowych dla potrzeb niezbędnych do udziału w konferencji.*"
          errors={errors}
        />
      </div>
      <button className={`${typography.button} ${styles.form__button}`}>
        Zapisz się
      </button>
    </form>
  );
}
export default RegistrationFrom;
