import styles from "./RegistrationFrom.module.css";
import { Link } from "react-router-dom";
import typography from "../../assets/css/Typography.module.css";
import { CheckboxField } from "./CheckboxField";
import { FieldWrapper } from "./FieldWrapper";
import { FormTextInput } from "./FormTextInput";
import { useForm } from "react-hook-form";
import { FormEmailInput } from "./FormEmailInput";

const FormPasswordWrapper = ({ register, errors }) => {
  return (
    <>
      <FormTextInput
        labelText={
          <>
            Hasło do <Link to="/">aplikacji QR Code</Link>*
          </>
        }
        type="password"
        name="password"
        register={register}
        errors={errors}
      />
      <FormTextInput
        labelText="Powtórz hasło*"
        type="password"
        name="repeatedPassword"
        register={register}
        errors={errors}
      />
    </>
  );
};

function RegistrationFrom() {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();
  const onSubmit = (data) => {
    console.log(data);
    reset({});
  };
  return (
    <form className={styles.form} onSubmit={handleSubmit(onSubmit)} noValidate>
      <div className={styles.form__section}>
        <FieldWrapper>
          <FormTextInput
            labelText="Imię*"
            name="firstName"
            register={register}
            errors={errors}
          />
          <FormTextInput
            labelText="Nazwisko*"
            name="lastName"
            register={register}
            errors={errors}
          />
        </FieldWrapper>
        <FormEmailInput
          labelText="Adres email*"
          name="email"
          register={register}
          errors={errors}
        />
        <FormPasswordWrapper register={register} errors={errors} />
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
