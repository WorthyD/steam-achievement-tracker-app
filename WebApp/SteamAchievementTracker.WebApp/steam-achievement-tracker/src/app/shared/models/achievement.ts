export interface IAchievement {
    appId: number,
    name: string,
    displayName: string,
    hidden: boolean,
    description: string,
    icon: string,
    iconGray: string,
    percent: number,
    steamId: number,
    achieved: boolean,
    unlockTimestamp: string
}
