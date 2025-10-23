
interface IProps {
    title: string;
}

const Header = ({ title }: IProps) => {
    return (
        <div className="flex" style={{
            justifyContent: 'space-between',
            alignItems: 'center',
            marginBottom: 'var(--spacing-lg)',
            paddingBottom: 'var(--spacing-sm)',
            borderBottom: '1px solid var(--border-color)'
        }}>
            <h1>{title}</h1>
        </div>
    )
}

export default Header;