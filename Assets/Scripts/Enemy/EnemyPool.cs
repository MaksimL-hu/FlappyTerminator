public class EnemyPool : GenericEnemyPool<Enemy>
{
    protected override Enemy InstantiateEnemy(int index)
    {
        Enemy enemy = base.InstantiateEnemy(index);
        enemy.Died += PutObject;

        return enemy;
    }

    protected override void DestroyEnemy(Enemy enemy)
    {
        enemy.Died -= PutObject;
        base.DestroyEnemy(enemy);
    }
}